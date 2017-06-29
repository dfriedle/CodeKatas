import com.google.common.collect.Lists;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.*;

public class Anagrams {

    public static final String WORDLIST_TXT = "wordlist.txt";

    public void run() {
        File file = getFile();
        List<String> words = readInWords(file);
        Map<String, List<String>> anagrams = findAnagrams(words);
        printAnagrams(anagrams);
    }

    private File getFile() {
        ClassLoader classLoader = getClass().getClassLoader();
        return new File(classLoader.getResource(WORDLIST_TXT).getFile());
    }

    private List<String> readInWords(File file) {
        List<String> words = Lists.newArrayList();
        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            String line;
            while ((line = br.readLine()) != null) {
                words.add(line);
            }
        } catch (Exception e) {
            System.err.println("Something went wrong :-/");
        }
        return words;
    }

    private Map<String,List<String>> findAnagrams(List<String> words) {
        Map<String, List<String>> anagrams = new HashMap();
        for (String word : words) {
            if (word.length() == 1) {
                continue;
            }
            String key = getSortedChars(word);
            if (!anagrams.containsKey(key)) {
                anagrams.put(key, new ArrayList<String>());
            }
            anagrams.get(key).add(word);
        }
        return anagrams;
    }

    private String getSortedChars(String word) {
        char[] chars = word.toCharArray();
        Arrays.sort(chars);
        return String.valueOf(chars);
    }

    private void printAnagrams(Map<String, List<String>> anagrams) {
        int countKeys = 0;
        int countValues = 0;
        for (Map.Entry<String, List<String>> entry : anagrams.entrySet()) {
            if (entry.getValue().size() > 1) {
                countKeys++;
                countValues += entry.getValue().size();
                //System.out.println(Joiner.on(", ").join(entry.getValue()));
            }
        }
        System.out.println("Sets: " + countKeys + ", Words: " + countValues);
    }
}
