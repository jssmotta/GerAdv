import React from 'react';
import { render } from '@testing-library/react';
import ModelosDocumentosIncContainer from '@/app/GerAdv_TS/ModelosDocumentos/Components/ModelosDocumentosIncContainer';
// ModelosDocumentosIncContainer.test.tsx
// Mock do ModelosDocumentosInc
jest.mock('@/app/GerAdv_TS/ModelosDocumentos/Crud/Inc/ModelosDocumentos', () => (props: any) => (
<div data-testid='modelosdocumentos-inc-mock' {...props} />
));
describe('ModelosDocumentosIncContainer', () => {
  it('deve renderizar ModelosDocumentosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ModelosDocumentosIncContainer id={id} navigator={mockNavigator} />
  );
  const modelosdocumentosInc = getByTestId('modelosdocumentos-inc-mock');
  expect(modelosdocumentosInc).toBeInTheDocument();
  expect(modelosdocumentosInc.getAttribute('id')).toBe(id.toString());

});
});