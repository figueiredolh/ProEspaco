export class ExtractCepNumbers {
  public static extractNumbers(cepString: string): string{
    let regexp: RegExp = /[-]/g;
    return cepString.replace(regexp, '');
  }
}
