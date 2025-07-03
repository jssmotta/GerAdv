// TipoEnderecoSistemaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoEnderecoSistemaGridAdapter } from '@/app/GerAdv_TS/TipoEnderecoSistema/Adapter/TipoEnderecoSistemaGridAdapter';
// Mock TipoEnderecoSistemaGrid component
jest.mock('@/app/GerAdv_TS/TipoEnderecoSistema/Crud/Grids/TipoEnderecoSistemaGrid', () => () => <div data-testid='tipoenderecosistema-grid-mock' />);
describe('TipoEnderecoSistemaGridAdapter', () => {
  it('should render TipoEnderecoSistemaGrid component', () => {
    const adapter = new TipoEnderecoSistemaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipoenderecosistema-grid-mock')).toBeInTheDocument();
  });
});