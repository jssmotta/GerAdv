// RamalGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { RamalGridAdapter } from '@/app/GerAdv_TS/Ramal/Adapter/RamalGridAdapter';
// Mock RamalGrid component
jest.mock('@/app/GerAdv_TS/Ramal/Crud/Grids/RamalGrid', () => () => <div data-testid='ramal-grid-mock' />);
describe('RamalGridAdapter', () => {
  it('should render RamalGrid component', () => {
    const adapter = new RamalGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('ramal-grid-mock')).toBeInTheDocument();
  });
});