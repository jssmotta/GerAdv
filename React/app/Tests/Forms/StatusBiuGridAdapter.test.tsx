// StatusBiuGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { StatusBiuGridAdapter } from '@/app/GerAdv_TS/StatusBiu/Adapter/StatusBiuGridAdapter';
// Mock StatusBiuGrid component
jest.mock('@/app/GerAdv_TS/StatusBiu/Crud/Grids/StatusBiuGrid', () => () => <div data-testid='statusbiu-grid-mock' />);
describe('StatusBiuGridAdapter', () => {
  it('should render StatusBiuGrid component', () => {
    const adapter = new StatusBiuGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('statusbiu-grid-mock')).toBeInTheDocument();
  });
});