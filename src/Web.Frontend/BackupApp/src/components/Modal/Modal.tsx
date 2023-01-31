import React from "react";
import { Button } from "../Button/Button";

import styles from "./Modal.module.css";

type Props = {
  title?: string;
  children?: React.ReactNode;
  acceptTitle?: string;
  onClose?: () => void;
  onAccept?: () => void;
  onCancel?: () => void;
};

export const Modal: React.FC<Props> = ({
  title,
  children,
  acceptTitle,
  onClose,
  onAccept,
  onCancel,
}) => {
  return (
    <div className={styles.Overlay}>
      <div className={styles.Modal}>
        <div className={styles.Header}>
          {!!title && <span className={styles.Title}>{title}</span>}
          <Button icon="close" onClick={onClose} />
        </div>
        <div className={styles.Content}>{children}</div>
        <div className={styles.Footer}>
          {onAccept && (
            <Button
              icon="save"
              label={acceptTitle || "Опубликовать"}
              primary
              className={styles.Button}
              onClick={onAccept}
            />
          )}
          {onCancel && (
            <Button
              icon="close"
              label="Отменить"
              className={styles.Button}
              onClick={onCancel}
            />
          )}
        </div>
      </div>
    </div>
  );
};
