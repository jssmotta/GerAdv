// ModelosDocumentosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ModelosDocumentosGridAdapter } from '@/app/GerAdv_TS/ModelosDocumentos/Adapter/ModelosDocumentosGridAdapter';
// Mock ModelosDocumentosGrid component
jest.mock('@/app/GerAdv_TS/ModelosDocumentos/Crud/Grids/ModelosDocumentosGrid', () => () => <div data-testid='modelosdocumentos-grid-mock' />);
describe('ModelosDocumentosGridAdapter', () => {
  it('should render ModelosDocumentosGrid component', () => {
    const adapter = new ModelosDocumentosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('modelosdocumentos-grid-mock')).toBeInTheDocument();
  });
});