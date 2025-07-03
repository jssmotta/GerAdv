// AreaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AreaGridAdapter } from '@/app/GerAdv_TS/Area/Adapter/AreaGridAdapter';
// Mock AreaGrid component
jest.mock('@/app/GerAdv_TS/Area/Crud/Grids/AreaGrid', () => () => <div data-testid='area-grid-mock' />);
describe('AreaGridAdapter', () => {
  it('should render AreaGrid component', () => {
    const adapter = new AreaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('area-grid-mock')).toBeInTheDocument();
  });
});