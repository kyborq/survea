interface IWordGroup {
  [key: string]: string[];
}

type TCity = {
  letter?: string;
  cities?: string[];
};

export const sortGroup = (object: IWordGroup) => {
  const ordered = Object.keys(object)
    .sort()
    .reduce((o: IWordGroup, key) => {
      o[key] = object[key];
      return o;
    }, {});

  return ordered;
};

export const groupToArray = (object: IWordGroup) => {
  const result: TCity[] = [];
  const keys = Object.keys(object);

  keys.forEach((key) => {
    const cityGroup: TCity = {
      letter: key,
      cities: object[key],
    };
    result.push(cityGroup);
  });

  return result;
};

export const groupWords = (words: string[]) => {
  const groupped: IWordGroup = {};

  words.forEach((word) => {
    const letter = word[0].toUpperCase();

    if (!groupped[letter]) {
      groupped[letter] = [];
    }

    groupped[letter].push(word);
  });

  const orderedGroup = sortGroup(groupped);

  return groupToArray(orderedGroup);
};
