import { Ng2FileUploadDemoPage } from './app.po';

describe('ng2-file-upload-demo App', () => {
  let page: Ng2FileUploadDemoPage;

  beforeEach(() => {
    page = new Ng2FileUploadDemoPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
