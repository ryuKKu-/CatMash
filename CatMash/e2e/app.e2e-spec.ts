import { CatMashPage } from './app.po';

describe('cat-mash App', () => {
  let page: CatMashPage;

  beforeEach(() => {
    page = new CatMashPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
