// TerceirosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TerceirosGridAdapter } from '@/app/GerAdv_TS/Terceiros/Adapter/TerceirosGridAdapter';
// Mock TerceirosGrid component
jest.mock('@/app/GerAdv_TS/Terceiros/Crud/Grids/TerceirosGrid', () => () => <div data-testid='terceiros-grid-mock' />);
describe('TerceirosGridAdapter', () => {
  it('should render TerceirosGrid component', () => {
    const adapter = new TerceirosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('terceiros-grid-mock')).toBeInTheDocument();
  });
});