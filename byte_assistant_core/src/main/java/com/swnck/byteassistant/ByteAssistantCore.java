package com.swnck.byteassistant;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.Banner;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;

@SpringBootApplication
public class ByteAssistantCore {
    public static final Logger LOGGER = LoggerFactory.getLogger(ByteAssistantCore.class);

    public static void main(String[] args) {
        long start = System.currentTimeMillis();
        new SpringApplicationBuilder(ByteAssistantCore.class)
                .bannerMode(Banner.Mode.OFF)
                .logStartupInfo(false)
                .run(args);

        long end = System.currentTimeMillis();

        LOGGER.info("Total execution time: {}ms", end - start);
    }
}
