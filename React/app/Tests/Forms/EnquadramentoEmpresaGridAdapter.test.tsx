// EnquadramentoEmpresaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { EnquadramentoEmpresaGridAdapter } from '@/app/GerAdv_TS/EnquadramentoEmpresa/Adapter/EnquadramentoEmpresaGridAdapter';
// Mock EnquadramentoEmpresaGrid component
jest.mock('@/app/GerAdv_TS/EnquadramentoEmpresa/Crud/Grids/EnquadramentoEmpresaGrid', () => () => <div data-testid='enquadramentoempresa-grid-mock' />);
describe('EnquadramentoEmpresaGridAdapter', () => {
  it('should render EnquadramentoEmpresaGrid component', () => {
    const adapter = new EnquadramentoEmpresaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('enquadramentoempresa-grid-mock')).toBeInTheDocument();
  });
});