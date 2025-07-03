// SMSAliceGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { SMSAliceGridAdapter } from '@/app/GerAdv_TS/SMSAlice/Adapter/SMSAliceGridAdapter';
// Mock SMSAliceGrid component
jest.mock('@/app/GerAdv_TS/SMSAlice/Crud/Grids/SMSAliceGrid', () => () => <div data-testid='smsalice-grid-mock' />);
describe('SMSAliceGridAdapter', () => {
  it('should render SMSAliceGrid component', () => {
    const adapter = new SMSAliceGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('smsalice-grid-mock')).toBeInTheDocument();
  });
});