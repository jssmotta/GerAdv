// UltimosProcessosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { UltimosProcessosGridAdapter } from '@/app/GerAdv_TS/UltimosProcessos/Adapter/UltimosProcessosGridAdapter';
// Mock UltimosProcessosGrid component
jest.mock('@/app/GerAdv_TS/UltimosProcessos/Crud/Grids/UltimosProcessosGrid', () => () => <div data-testid='ultimosprocessos-grid-mock' />);
describe('UltimosProcessosGridAdapter', () => {
  it('should render UltimosProcessosGrid component', () => {
    const adapter = new UltimosProcessosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('ultimosprocessos-grid-mock')).toBeInTheDocument();
  });
});