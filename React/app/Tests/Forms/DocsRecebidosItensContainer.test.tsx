import React from 'react';
import { render } from '@testing-library/react';
import DocsRecebidosItensIncContainer from '@/app/GerAdv_TS/DocsRecebidosItens/Components/DocsRecebidosItensIncContainer';
// DocsRecebidosItensIncContainer.test.tsx
// Mock do DocsRecebidosItensInc
jest.mock('@/app/GerAdv_TS/DocsRecebidosItens/Crud/Inc/DocsRecebidosItens', () => (props: any) => (
<div data-testid='docsrecebidositens-inc-mock' {...props} />
));
describe('DocsRecebidosItensIncContainer', () => {
  it('deve renderizar DocsRecebidosItensInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <DocsRecebidosItensIncContainer id={id} navigator={mockNavigator} />
  );
  const docsrecebidositensInc = getByTestId('docsrecebidositens-inc-mock');
  expect(docsrecebidositensInc).toBeInTheDocument();
  expect(docsrecebidositensInc.getAttribute('id')).toBe(id.toString());

});
});