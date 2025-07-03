import React from 'react';
import { render } from '@testing-library/react';
import EndTitIncContainer from '@/app/GerAdv_TS/EndTit/Components/EndTitIncContainer';
// EndTitIncContainer.test.tsx
// Mock do EndTitInc
jest.mock('@/app/GerAdv_TS/EndTit/Crud/Inc/EndTit', () => (props: any) => (
<div data-testid='endtit-inc-mock' {...props} />
));
describe('EndTitIncContainer', () => {
  it('deve renderizar EndTitInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <EndTitIncContainer id={id} navigator={mockNavigator} />
  );
  const endtitInc = getByTestId('endtit-inc-mock');
  expect(endtitInc).toBeInTheDocument();
  expect(endtitInc.getAttribute('id')).toBe(id.toString());

});
});