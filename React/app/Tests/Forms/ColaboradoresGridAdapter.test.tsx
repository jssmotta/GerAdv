// ColaboradoresGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ColaboradoresGridAdapter } from '@/app/GerAdv_TS/Colaboradores/Adapter/ColaboradoresGridAdapter';
// Mock ColaboradoresGrid component
jest.mock('@/app/GerAdv_TS/Colaboradores/Crud/Grids/ColaboradoresGrid', () => () => <div data-testid='colaboradores-grid-mock' />);
describe('ColaboradoresGridAdapter', () => {
  it('should render ColaboradoresGrid component', () => {
    const adapter = new ColaboradoresGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('colaboradores-grid-mock')).toBeInTheDocument();
  });
});