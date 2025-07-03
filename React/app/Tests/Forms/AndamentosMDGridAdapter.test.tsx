// AndamentosMDGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AndamentosMDGridAdapter } from '@/app/GerAdv_TS/AndamentosMD/Adapter/AndamentosMDGridAdapter';
// Mock AndamentosMDGrid component
jest.mock('@/app/GerAdv_TS/AndamentosMD/Crud/Grids/AndamentosMDGrid', () => () => <div data-testid='andamentosmd-grid-mock' />);
describe('AndamentosMDGridAdapter', () => {
  it('should render AndamentosMDGrid component', () => {
    const adapter = new AndamentosMDGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('andamentosmd-grid-mock')).toBeInTheDocument();
  });
});