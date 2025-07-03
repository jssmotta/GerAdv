// LivroCaixaClientesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { LivroCaixaClientesGridAdapter } from '@/app/GerAdv_TS/LivroCaixaClientes/Adapter/LivroCaixaClientesGridAdapter';
// Mock LivroCaixaClientesGrid component
jest.mock('@/app/GerAdv_TS/LivroCaixaClientes/Crud/Grids/LivroCaixaClientesGrid', () => () => <div data-testid='livrocaixaclientes-grid-mock' />);
describe('LivroCaixaClientesGridAdapter', () => {
  it('should render LivroCaixaClientesGrid component', () => {
    const adapter = new LivroCaixaClientesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('livrocaixaclientes-grid-mock')).toBeInTheDocument();
  });
});