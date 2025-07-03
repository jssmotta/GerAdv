import React from 'react';
import { render } from '@testing-library/react';
import ObjetosIncContainer from '@/app/GerAdv_TS/Objetos/Components/ObjetosIncContainer';
// ObjetosIncContainer.test.tsx
// Mock do ObjetosInc
jest.mock('@/app/GerAdv_TS/Objetos/Crud/Inc/Objetos', () => (props: any) => (
<div data-testid='objetos-inc-mock' {...props} />
));
describe('ObjetosIncContainer', () => {
  it('deve renderizar ObjetosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ObjetosIncContainer id={id} navigator={mockNavigator} />
  );
  const objetosInc = getByTestId('objetos-inc-mock');
  expect(objetosInc).toBeInTheDocument();
  expect(objetosInc.getAttribute('id')).toBe(id.toString());

});
});