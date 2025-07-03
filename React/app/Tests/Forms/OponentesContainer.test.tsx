import React from 'react';
import { render } from '@testing-library/react';
import OponentesIncContainer from '@/app/GerAdv_TS/Oponentes/Components/OponentesIncContainer';
// OponentesIncContainer.test.tsx
// Mock do OponentesInc
jest.mock('@/app/GerAdv_TS/Oponentes/Crud/Inc/Oponentes', () => (props: any) => (
<div data-testid='oponentes-inc-mock' {...props} />
));
describe('OponentesIncContainer', () => {
  it('deve renderizar OponentesInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <OponentesIncContainer id={id} navigator={mockNavigator} />
  );
  const oponentesInc = getByTestId('oponentes-inc-mock');
  expect(oponentesInc).toBeInTheDocument();
  expect(oponentesInc.getAttribute('id')).toBe(id.toString());

});
});