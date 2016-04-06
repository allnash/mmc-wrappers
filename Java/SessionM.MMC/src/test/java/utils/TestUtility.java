package utils;

import java.util.Random;

/**
 * Created by ngadre on 12/10/15.
 */
public class TestUtility {

    public static String generatePin() {
        Random generator = new Random();
        generator.setSeed(System.currentTimeMillis());

        int num = generator.nextInt(99999) + 99999;
        if (num < 100000 || num > 999999) {
            num = generator.nextInt(99999) + 99999;
            if (num < 100000 || num > 999999) {
                return null;
            }
        }
        return String.valueOf(num);
    }

    public static String generateRandomString(){
        RandomString random = new RandomString(6);
        return random.nextString();
    }

    //Used to set length of random gener
    public static String generateRandomSetLength(int length) {
        Random random = new Random();
        char[] digits = new char[length];
        digits[0] = (char) (random.nextInt(9) + '1');
        for (int i = 1; i < length; i++) {
            digits[i] = (char) (random.nextInt(10) + '0');
        }
        return new String(digits);
    }


}



class RandomString {

    private static final char[] symbols = new char[36];

    static {
        for (int idx = 0; idx < 10; ++idx)
            symbols[idx] = (char) ('0' + idx);
        for (int idx = 10; idx < 36; ++idx)
            symbols[idx] = (char) ('a' + idx - 10);
    }

    private final Random random = new Random();

    private final char[] buf;

    public RandomString(int length) {
        random.setSeed(System.currentTimeMillis());
        if (length < 1)
            throw new IllegalArgumentException("length < 1: " + length);
        buf = new char[length];
    }

    public String nextString() {
        for (int idx = 0; idx < buf.length; ++idx)
            buf[idx] = symbols[random.nextInt(symbols.length)];
        return new String(buf);
    }


}

