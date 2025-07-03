// FuncaoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { FuncaoGridAdapter } from '@/app/GerAdv_TS/Funcao/Adapter/FuncaoGridAdapter';
// Mock FuncaoGrid component
jest.mock('@/app/GerAdv_TS/Funcao/Crud/Grids/FuncaoGrid', () => () => <div data-testid='funcao-grid-mock' />);
describe('FuncaoGridAdapter', () => {
  it('should render FuncaoGrid component', () => {
    const adapter = new FuncaoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('funcao-grid-mock')).toBeInTheDocument();
  });
});