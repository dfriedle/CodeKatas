import com.google.common.base.Stopwatch;

import java.util.concurrent.TimeUnit;

public class CodeKatas {

    public static void main(String[] args)  {
        Stopwatch stopwatch = Stopwatch.createStarted();

        Anagrams anagrams = new Anagrams();
        anagrams.run();

        stopwatch.stop();
        System.out.println("Time:" + stopwatch.elapsed(TimeUnit.MILLISECONDS));
    }
}
