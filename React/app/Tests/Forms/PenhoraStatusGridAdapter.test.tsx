// PenhoraStatusGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PenhoraStatusGridAdapter } from '@/app/GerAdv_TS/PenhoraStatus/Adapter/PenhoraStatusGridAdapter';
// Mock PenhoraStatusGrid component
jest.mock('@/app/GerAdv_TS/PenhoraStatus/Crud/Grids/PenhoraStatusGrid', () => () => <div data-testid='penhorastatus-grid-mock' />);
describe('PenhoraStatusGridAdapter', () => {
  it('should render PenhoraStatusGrid component', () => {
    const adapter = new PenhoraStatusGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('penhorastatus-grid-mock')).toBeInTheDocument();
  });
});