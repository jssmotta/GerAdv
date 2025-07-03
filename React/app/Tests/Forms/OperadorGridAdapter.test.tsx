// OperadorGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OperadorGridAdapter } from '@/app/GerAdv_TS/Operador/Adapter/OperadorGridAdapter';
// Mock OperadorGrid component
jest.mock('@/app/GerAdv_TS/Operador/Crud/Grids/OperadorGrid', () => () => <div data-testid='operador-grid-mock' />);
describe('OperadorGridAdapter', () => {
  it('should render OperadorGrid component', () => {
    const adapter = new OperadorGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('operador-grid-mock')).toBeInTheDocument();
  });
});