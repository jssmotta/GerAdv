import React from 'react';
import { render } from '@testing-library/react';
import AndCompIncContainer from '@/app/GerAdv_TS/AndComp/Components/AndCompIncContainer';
// AndCompIncContainer.test.tsx
// Mock do AndCompInc
jest.mock('@/app/GerAdv_TS/AndComp/Crud/Inc/AndComp', () => (props: any) => (
<div data-testid='andcomp-inc-mock' {...props} />
));
describe('AndCompIncContainer', () => {
  it('deve renderizar AndCompInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AndCompIncContainer id={id} navigator={mockNavigator} />
  );
  const andcompInc = getByTestId('andcomp-inc-mock');
  expect(andcompInc).toBeInTheDocument();
  expect(andcompInc.getAttribute('id')).toBe(id.toString());

});
});