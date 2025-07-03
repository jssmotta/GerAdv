import React from 'react';
import { render } from '@testing-library/react';
import UltimosProcessosIncContainer from '@/app/GerAdv_TS/UltimosProcessos/Components/UltimosProcessosIncContainer';
// UltimosProcessosIncContainer.test.tsx
// Mock do UltimosProcessosInc
jest.mock('@/app/GerAdv_TS/UltimosProcessos/Crud/Inc/UltimosProcessos', () => (props: any) => (
<div data-testid='ultimosprocessos-inc-mock' {...props} />
));
describe('UltimosProcessosIncContainer', () => {
  it('deve renderizar UltimosProcessosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <UltimosProcessosIncContainer id={id} navigator={mockNavigator} />
  );
  const ultimosprocessosInc = getByTestId('ultimosprocessos-inc-mock');
  expect(ultimosprocessosInc).toBeInTheDocument();
  expect(ultimosprocessosInc.getAttribute('id')).toBe(id.toString());

});
});