// FornecedoresGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { FornecedoresGridAdapter } from '@/app/GerAdv_TS/Fornecedores/Adapter/FornecedoresGridAdapter';
// Mock FornecedoresGrid component
jest.mock('@/app/GerAdv_TS/Fornecedores/Crud/Grids/FornecedoresGrid', () => () => <div data-testid='fornecedores-grid-mock' />);
describe('FornecedoresGridAdapter', () => {
  it('should render FornecedoresGrid component', () => {
    const adapter = new FornecedoresGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('fornecedores-grid-mock')).toBeInTheDocument();
  });
});