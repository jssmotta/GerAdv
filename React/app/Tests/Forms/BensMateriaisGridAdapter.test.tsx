// BensMateriaisGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { BensMateriaisGridAdapter } from '@/app/GerAdv_TS/BensMateriais/Adapter/BensMateriaisGridAdapter';
// Mock BensMateriaisGrid component
jest.mock('@/app/GerAdv_TS/BensMateriais/Crud/Grids/BensMateriaisGrid', () => () => <div data-testid='bensmateriais-grid-mock' />);
describe('BensMateriaisGridAdapter', () => {
  it('should render BensMateriaisGrid component', () => {
    const adapter = new BensMateriaisGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('bensmateriais-grid-mock')).toBeInTheDocument();
  });
});