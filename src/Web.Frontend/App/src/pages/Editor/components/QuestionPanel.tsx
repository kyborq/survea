import React from "react";

import { Button } from "../../../components/button/Button";
import { Card } from "../../../components/card/Card";

import styles from "./QuestionPanel.module.css";

type Props = {
  addSingle?: () => void;
  addMultiple?: () => void;
  addText?: () => void;
};

export const QuestionPanel: React.FC<Props> = ({
  addSingle,
  addMultiple,
  addText,
}) => {
  return (
    <Card
      title="Добавить вопрос"
      className={styles.Form}
      contentClassName={styles.Panel}
    >
      <Button label="Одиночный" icon="circleCheck" fill onClick={addSingle} />
      <Button
        label="Множественный"
        icon="checkbox"
        fill
        onClick={addMultiple}
      />
      <Button label="Текстовый" icon="text" fill onClick={addText} />
    </Card>
  );
};
