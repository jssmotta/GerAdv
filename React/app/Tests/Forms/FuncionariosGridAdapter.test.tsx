// FuncionariosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { FuncionariosGridAdapter } from '@/app/GerAdv_TS/Funcionarios/Adapter/FuncionariosGridAdapter';
// Mock FuncionariosGrid component
jest.mock('@/app/GerAdv_TS/Funcionarios/Crud/Grids/FuncionariosGrid', () => () => <div data-testid='funcionarios-grid-mock' />);
describe('FuncionariosGridAdapter', () => {
  it('should render FuncionariosGrid component', () => {
    const adapter = new FuncionariosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('funcionarios-grid-mock')).toBeInTheDocument();
  });
});