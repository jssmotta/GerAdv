import React from 'react';
import { render } from '@testing-library/react';
import TipoModeloDocumentoIncContainer from '@/app/GerAdv_TS/TipoModeloDocumento/Components/TipoModeloDocumentoIncContainer';
// TipoModeloDocumentoIncContainer.test.tsx
// Mock do TipoModeloDocumentoInc
jest.mock('@/app/GerAdv_TS/TipoModeloDocumento/Crud/Inc/TipoModeloDocumento', () => (props: any) => (
<div data-testid='tipomodelodocumento-inc-mock' {...props} />
));
describe('TipoModeloDocumentoIncContainer', () => {
  it('deve renderizar TipoModeloDocumentoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <TipoModeloDocumentoIncContainer id={id} navigator={mockNavigator} />
  );
  const tipomodelodocumentoInc = getByTestId('tipomodelodocumento-inc-mock');
  expect(tipomodelodocumentoInc).toBeInTheDocument();
  expect(tipomodelodocumentoInc.getAttribute('id')).toBe(id.toString());

});
});