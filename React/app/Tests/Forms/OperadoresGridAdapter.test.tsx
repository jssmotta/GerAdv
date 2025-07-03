// OperadoresGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OperadoresGridAdapter } from '@/app/GerAdv_TS/Operadores/Adapter/OperadoresGridAdapter';
// Mock OperadoresGrid component
jest.mock('@/app/GerAdv_TS/Operadores/Crud/Grids/OperadoresGrid', () => () => <div data-testid='operadores-grid-mock' />);
describe('OperadoresGridAdapter', () => {
  it('should render OperadoresGrid component', () => {
    const adapter = new OperadoresGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('operadores-grid-mock')).toBeInTheDocument();
  });
});