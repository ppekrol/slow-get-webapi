package pl.ais;

import java.io.InputStream;
import java.net.URL;
import java.util.Date;

import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.methods.GetMethod;
import org.apache.commons.io.IOUtils;

public class Program {


  public static void performGetsUsingWebRequest(String inputUrl) throws Exception {
    DummyStream dummyStream = new DummyStream();
    for (int i = 0 ; i < 100; i++) {
      long start = new Date().getTime();
      URL url = new URL(inputUrl);
      InputStream inputStream = url.openStream();
      IOUtils.copy(inputStream, dummyStream);
      long end = new Date().getTime();
      System.out.println(String.format("%03d: %d", i, (end - start)));
    }
  }

  public static void performGetsUsingHttpClient(String inputUrl) throws Exception {
    HttpClient client = new HttpClient();

    for (int i = 0; i < 10000; i++) {
      GetMethod getMethod = new GetMethod(inputUrl);
      long start = new Date().getTime();
      client.executeMethod(getMethod);
      getMethod.releaseConnection();
      long end = new Date().getTime();
      System.out.println(String.format("%03d: %d", i, (end - start)));

    }
  }

  public static void main(String[] args) throws Exception {
    if (args.length < 2) {
      System.err.println("usage: program url [url|http]");
    } else {
      String inputUrl = args[0];
      String mode = args[1];
      if ("url".equals(mode)) {
        performGetsUsingWebRequest(inputUrl);
      } else if ("http".equals(mode)) {
        performGetsUsingHttpClient(inputUrl);
      } else {
        System.err.println("Invalid mode.");
      }
    }
  }
}
