import React from 'react';
import { render } from '@testing-library/react';
import ContatoCRMOperadorIncContainer from '@/app/GerAdv_TS/ContatoCRMOperador/Components/ContatoCRMOperadorIncContainer';
// ContatoCRMOperadorIncContainer.test.tsx
// Mock do ContatoCRMOperadorInc
jest.mock('@/app/GerAdv_TS/ContatoCRMOperador/Crud/Inc/ContatoCRMOperador', () => (props: any) => (
<div data-testid='contatocrmoperador-inc-mock' {...props} />
));
describe('ContatoCRMOperadorIncContainer', () => {
  it('deve renderizar ContatoCRMOperadorInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ContatoCRMOperadorIncContainer id={id} navigator={mockNavigator} />
  );
  const contatocrmoperadorInc = getByTestId('contatocrmoperador-inc-mock');
  expect(contatocrmoperadorInc).toBeInTheDocument();
  expect(contatocrmoperadorInc.getAttribute('id')).toBe(id.toString());

});
});