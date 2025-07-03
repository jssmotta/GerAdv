// GraphGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GraphGridAdapter } from '@/app/GerAdv_TS/Graph/Adapter/GraphGridAdapter';
// Mock GraphGrid component
jest.mock('@/app/GerAdv_TS/Graph/Crud/Grids/GraphGrid', () => () => <div data-testid='graph-grid-mock' />);
describe('GraphGridAdapter', () => {
  it('should render GraphGrid component', () => {
    const adapter = new GraphGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('graph-grid-mock')).toBeInTheDocument();
  });
});