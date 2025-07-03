import React from 'react';
import { render } from '@testing-library/react';
import OponentesRepLegalIncContainer from '@/app/GerAdv_TS/OponentesRepLegal/Components/OponentesRepLegalIncContainer';
// OponentesRepLegalIncContainer.test.tsx
// Mock do OponentesRepLegalInc
jest.mock('@/app/GerAdv_TS/OponentesRepLegal/Crud/Inc/OponentesRepLegal', () => (props: any) => (
<div data-testid='oponentesreplegal-inc-mock' {...props} />
));
describe('OponentesRepLegalIncContainer', () => {
  it('deve renderizar OponentesRepLegalInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <OponentesRepLegalIncContainer id={id} navigator={mockNavigator} />
  );
  const oponentesreplegalInc = getByTestId('oponentesreplegal-inc-mock');
  expect(oponentesreplegalInc).toBeInTheDocument();
  expect(oponentesreplegalInc.getAttribute('id')).toBe(id.toString());

});
});