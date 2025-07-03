// GUTMatrizGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GUTMatrizGridAdapter } from '@/app/GerAdv_TS/GUTMatriz/Adapter/GUTMatrizGridAdapter';
// Mock GUTMatrizGrid component
jest.mock('@/app/GerAdv_TS/GUTMatriz/Crud/Grids/GUTMatrizGrid', () => () => <div data-testid='gutmatriz-grid-mock' />);
describe('GUTMatrizGridAdapter', () => {
  it('should render GUTMatrizGrid component', () => {
    const adapter = new GUTMatrizGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('gutmatriz-grid-mock')).toBeInTheDocument();
  });
});