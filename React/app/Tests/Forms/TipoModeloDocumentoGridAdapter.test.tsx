// TipoModeloDocumentoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoModeloDocumentoGridAdapter } from '@/app/GerAdv_TS/TipoModeloDocumento/Adapter/TipoModeloDocumentoGridAdapter';
// Mock TipoModeloDocumentoGrid component
jest.mock('@/app/GerAdv_TS/TipoModeloDocumento/Crud/Grids/TipoModeloDocumentoGrid', () => () => <div data-testid='tipomodelodocumento-grid-mock' />);
describe('TipoModeloDocumentoGridAdapter', () => {
  it('should render TipoModeloDocumentoGrid component', () => {
    const adapter = new TipoModeloDocumentoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipomodelodocumento-grid-mock')).toBeInTheDocument();
  });
});