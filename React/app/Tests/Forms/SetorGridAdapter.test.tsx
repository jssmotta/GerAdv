// SetorGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { SetorGridAdapter } from '@/app/GerAdv_TS/Setor/Adapter/SetorGridAdapter';
// Mock SetorGrid component
jest.mock('@/app/GerAdv_TS/Setor/Crud/Grids/SetorGrid', () => () => <div data-testid='setor-grid-mock' />);
describe('SetorGridAdapter', () => {
  it('should render SetorGrid component', () => {
    const adapter = new SetorGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('setor-grid-mock')).toBeInTheDocument();
  });
});