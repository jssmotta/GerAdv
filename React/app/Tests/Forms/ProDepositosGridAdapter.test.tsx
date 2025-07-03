// ProDepositosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProDepositosGridAdapter } from '@/app/GerAdv_TS/ProDepositos/Adapter/ProDepositosGridAdapter';
// Mock ProDepositosGrid component
jest.mock('@/app/GerAdv_TS/ProDepositos/Crud/Grids/ProDepositosGrid', () => () => <div data-testid='prodepositos-grid-mock' />);
describe('ProDepositosGridAdapter', () => {
  it('should render ProDepositosGrid component', () => {
    const adapter = new ProDepositosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('prodepositos-grid-mock')).toBeInTheDocument();
  });
});