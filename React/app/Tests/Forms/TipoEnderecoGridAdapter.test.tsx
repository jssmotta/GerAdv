// TipoEnderecoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoEnderecoGridAdapter } from '@/app/GerAdv_TS/TipoEndereco/Adapter/TipoEnderecoGridAdapter';
// Mock TipoEnderecoGrid component
jest.mock('@/app/GerAdv_TS/TipoEndereco/Crud/Grids/TipoEnderecoGrid', () => () => <div data-testid='tipoendereco-grid-mock' />);
describe('TipoEnderecoGridAdapter', () => {
  it('should render TipoEnderecoGrid component', () => {
    const adapter = new TipoEnderecoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipoendereco-grid-mock')).toBeInTheDocument();
  });
});