// AlarmSMSGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AlarmSMSGridAdapter } from '@/app/GerAdv_TS/AlarmSMS/Adapter/AlarmSMSGridAdapter';
// Mock AlarmSMSGrid component
jest.mock('@/app/GerAdv_TS/AlarmSMS/Crud/Grids/AlarmSMSGrid', () => () => <div data-testid='alarmsms-grid-mock' />);
describe('AlarmSMSGridAdapter', () => {
  it('should render AlarmSMSGrid component', () => {
    const adapter = new AlarmSMSGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('alarmsms-grid-mock')).toBeInTheDocument();
  });
});