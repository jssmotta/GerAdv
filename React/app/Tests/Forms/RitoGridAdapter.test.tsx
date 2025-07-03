// RitoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { RitoGridAdapter } from '@/app/GerAdv_TS/Rito/Adapter/RitoGridAdapter';
// Mock RitoGrid component
jest.mock('@/app/GerAdv_TS/Rito/Crud/Grids/RitoGrid', () => () => <div data-testid='rito-grid-mock' />);
describe('RitoGridAdapter', () => {
  it('should render RitoGrid component', () => {
    const adapter = new RitoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('rito-grid-mock')).toBeInTheDocument();
  });
});