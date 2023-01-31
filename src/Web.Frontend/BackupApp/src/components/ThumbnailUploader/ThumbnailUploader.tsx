import React from "react";
import { Icon } from "../Icon";

import styles from "./ThumbnailUploader.module.css";

export const ThumbnailUploader = () => {
  return (
    <label className={styles.ThumbnailUploader}>
      <Icon name="upload" fill="#c7c7c7" />
      <input type="file" className={styles.Input} />
    </label>
  );
};
