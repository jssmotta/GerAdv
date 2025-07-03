// PenhoraGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PenhoraGridAdapter } from '@/app/GerAdv_TS/Penhora/Adapter/PenhoraGridAdapter';
// Mock PenhoraGrid component
jest.mock('@/app/GerAdv_TS/Penhora/Crud/Grids/PenhoraGrid', () => () => <div data-testid='penhora-grid-mock' />);
describe('PenhoraGridAdapter', () => {
  it('should render PenhoraGrid component', () => {
    const adapter = new PenhoraGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('penhora-grid-mock')).toBeInTheDocument();
  });
});