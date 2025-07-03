// StatusHTrabGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { StatusHTrabGridAdapter } from '@/app/GerAdv_TS/StatusHTrab/Adapter/StatusHTrabGridAdapter';
// Mock StatusHTrabGrid component
jest.mock('@/app/GerAdv_TS/StatusHTrab/Crud/Grids/StatusHTrabGrid', () => () => <div data-testid='statushtrab-grid-mock' />);
describe('StatusHTrabGridAdapter', () => {
  it('should render StatusHTrabGrid component', () => {
    const adapter = new StatusHTrabGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('statushtrab-grid-mock')).toBeInTheDocument();
  });
});