import React from "react";
import { Button } from "../../../components/Button/Button";

import styles from "./Tools.module.css";

type Props = {
  handleOneChoice: () => void;
  handleMultipleChoice: () => void;
  handleTextChoice: () => void;
};

export const Tools: React.FC<Props> = ({
  handleMultipleChoice,
  handleOneChoice,
  handleTextChoice,
}) => {
  return (
    <div className={styles.Tools}>
      <h3 className={styles.Title}>Инструменты</h3>
      <div className={styles.Panel}>
        <Button
          icon="addCircle"
          label="Выбор одного"
          onClick={handleMultipleChoice}
        />
        <Button
          icon="addCircle"
          label="Выбор нескольких"
          onClick={handleOneChoice}
        />
        <Button icon="addCircle" label="Текст" onClick={handleTextChoice} />
      </div>
    </div>
  );
};
