import React from 'react';
import { render } from '@testing-library/react';
import AlarmSMSIncContainer from '@/app/GerAdv_TS/AlarmSMS/Components/AlarmSMSIncContainer';
// AlarmSMSIncContainer.test.tsx
// Mock do AlarmSMSInc
jest.mock('@/app/GerAdv_TS/AlarmSMS/Crud/Inc/AlarmSMS', () => (props: any) => (
<div data-testid='alarmsms-inc-mock' {...props} />
));
describe('AlarmSMSIncContainer', () => {
  it('deve renderizar AlarmSMSInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AlarmSMSIncContainer id={id} navigator={mockNavigator} />
  );
  const alarmsmsInc = getByTestId('alarmsms-inc-mock');
  expect(alarmsmsInc).toBeInTheDocument();
  expect(alarmsmsInc.getAttribute('id')).toBe(id.toString());

});
});