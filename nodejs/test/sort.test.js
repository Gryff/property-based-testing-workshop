describe('sort', () => {
  it('sorts a simple array of 2, 3, 1', () => {
    const myArray = [2, 3, 1]
    expect(sort(myArray)).toEqual([1, 2, 3])
  })
})

function sort (arr) {
  return arr.sort()
}
