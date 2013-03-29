package pl.ais;

import java.io.IOException;
import java.io.OutputStream;

public class DummyStream extends OutputStream {

  @Override
  public void write(int b) throws IOException {
    // do nothing
  }

}
