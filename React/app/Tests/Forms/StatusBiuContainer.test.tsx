import React from 'react';
import { render } from '@testing-library/react';
import StatusBiuIncContainer from '@/app/GerAdv_TS/StatusBiu/Components/StatusBiuIncContainer';
// StatusBiuIncContainer.test.tsx
// Mock do StatusBiuInc
jest.mock('@/app/GerAdv_TS/StatusBiu/Crud/Inc/StatusBiu', () => (props: any) => (
<div data-testid='statusbiu-inc-mock' {...props} />
));
describe('StatusBiuIncContainer', () => {
  it('deve renderizar StatusBiuInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <StatusBiuIncContainer id={id} navigator={mockNavigator} />
  );
  const statusbiuInc = getByTestId('statusbiu-inc-mock');
  expect(statusbiuInc).toBeInTheDocument();
  expect(statusbiuInc.getAttribute('id')).toBe(id.toString());

});
});