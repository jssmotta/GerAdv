// AndCompGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AndCompGridAdapter } from '@/app/GerAdv_TS/AndComp/Adapter/AndCompGridAdapter';
// Mock AndCompGrid component
jest.mock('@/app/GerAdv_TS/AndComp/Crud/Grids/AndCompGrid', () => () => <div data-testid='andcomp-grid-mock' />);
describe('AndCompGridAdapter', () => {
  it('should render AndCompGrid component', () => {
    const adapter = new AndCompGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('andcomp-grid-mock')).toBeInTheDocument();
  });
});