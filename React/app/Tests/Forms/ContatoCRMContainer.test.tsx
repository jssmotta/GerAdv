import React from 'react';
import { render } from '@testing-library/react';
import ContatoCRMIncContainer from '@/app/GerAdv_TS/ContatoCRM/Components/ContatoCRMIncContainer';
// ContatoCRMIncContainer.test.tsx
// Mock do ContatoCRMInc
jest.mock('@/app/GerAdv_TS/ContatoCRM/Crud/Inc/ContatoCRM', () => (props: any) => (
<div data-testid='contatocrm-inc-mock' {...props} />
));
describe('ContatoCRMIncContainer', () => {
  it('deve renderizar ContatoCRMInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ContatoCRMIncContainer id={id} navigator={mockNavigator} />
  );
  const contatocrmInc = getByTestId('contatocrm-inc-mock');
  expect(contatocrmInc).toBeInTheDocument();
  expect(contatocrmInc.getAttribute('id')).toBe(id.toString());

});
});